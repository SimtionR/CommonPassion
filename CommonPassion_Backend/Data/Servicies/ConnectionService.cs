using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class ConnectionService : IConnectionService
    {
        private readonly IProfileService _profileService;
        private readonly CommonPassionDbContext _ctx;

        public ConnectionService(CommonPassionDbContext ctx, IProfileService profileService)
        {
            _profileService = profileService;
            _ctx = ctx;
        }


        public async Task<ResponsePending> AcceptConnectionPendingAsync(ResponsePending responsePending)
        {
            var receiverProfile = await _profileService.GetProfileByProfileId(responsePending.ReceiverId);

            if (receiverProfile != null)
            {
                responsePending.IsAccepted = true;
                await _ctx.AddAsync(responsePending);

                receiverProfile.ResponsePendings.Add(responsePending);
                var connectionPendingToRemove = await _ctx.ConnectionPendings.Where(c => c.Id == responsePending.PendingId).FirstOrDefaultAsync();
                _ctx.ConnectionPendings.Remove(connectionPendingToRemove);
                await _ctx.SaveChangesAsync();

                await CreateConnectionAsync(responsePending);



                return responsePending;

            }

            throw new Exception("Could not accept request");
        }

        public async Task CreateConnectionAsync(ResponsePending responsePending)
        {
            try
            {
                var senderConnection = new Connection
                {
                    ProfileConnectionId = responsePending.ReceiverId,
                    ProfileId = responsePending.SenderId,
                    ProfileUserName = responsePending.ReceiverName,
                    ProfilePicture = responsePending.ReceiverPhoto
                };

                var receiverConnection = new Connection
                {
                    ProfileConnectionId = responsePending.SenderId,
                    ProfileId = responsePending.ReceiverId,
                    ProfileUserName = responsePending.SenderName,
                    ProfilePicture = responsePending.SenderPhoto
                };

                await _ctx.Connections.AddAsync(senderConnection);
                await _ctx.Connections.AddAsync(receiverConnection);

                var receiverProfileToUpdate = await _profileService.GetProfileByProfileId(responsePending.ReceiverId);
                var senderProfileToUpdate = await _profileService.GetProfileByProfileId(responsePending.SenderId);


                receiverProfileToUpdate.Connections.Add(receiverConnection);
                senderProfileToUpdate.Connections.Add(senderConnection);

                await _ctx.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception("Could not create connection:" + ex.Message);
            }



        }

        public async Task<ResponsePending> DeclineConnectionPendingAsync(ResponsePending responsePending)
        {


            var receiverProfile = await _profileService.GetProfileByProfileId(responsePending.ReceiverId);

            if (receiverProfile != null)
            {
                responsePending.IsAccepted = false;
                await _ctx.AddAsync(responsePending);

                receiverProfile.ResponsePendings.Add(responsePending);
                var connectionPendingToRemove = await _ctx.ConnectionPendings.Where(c => c.Id == responsePending.PendingId).FirstOrDefaultAsync();
                _ctx.ConnectionPendings.Remove(connectionPendingToRemove);
                await _ctx.SaveChangesAsync();

                return responsePending;
            }

            throw new Exception("Could not decline request");



        }

        public async Task<bool> DeleteConnectinPendingAsync(int conncetionPending)
        {
            var connectionPendingToDelete = await GetConnectionPendingByIdAsync(conncetionPending);

            if (connectionPendingToDelete != null)
            {
                _ctx.ConnectionPendings.Remove(connectionPendingToDelete);

                await _ctx.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<bool> DeleteConnectionByIdAsync(int connectionId)
        {
            var connectionToDelete = await _ctx.Connections.Where(c => c.Id == connectionId).FirstOrDefaultAsync();

            if (connectionToDelete != null)
            {
                _ctx.Connections.Remove(connectionToDelete);
                await _ctx.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<Connection> GetConnectionByIdAsync(int connectionId)
        {
            return await _ctx.Connections.Where(c => c.Id == connectionId).FirstOrDefaultAsync();
        }

        public async Task<ConnectionPending> GetConnectionPendingByIdAsync(int connectionPendingId)
        {
            return await _ctx.ConnectionPendings.Where(c => c.Id == connectionPendingId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Connection>> GetConnectionsByProfileId(int profileId)
        {
            return await _ctx.Connections.Where(c => c.ProfileId == profileId).ToListAsync();
        }

        public async Task<IEnumerable<ConnectionPending>> GetConnectionsPendingByProfileIdAsync(int profileId)
        {
            return await _ctx.ConnectionPendings.Where(c => c.ReceiverId == profileId).ToListAsync();
        }

        public async Task<ResponsePending> GetResponsePendingByIdAsync(int connectionPendingId)
        {
            return await _ctx.ResponsePendings.Where(r => r.Id == connectionPendingId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ResponsePending>> GetResponsePendingsByProfileIdAsync(int profileId)
        {
            return await _ctx.ResponsePendings.Where(r => r.ReceiverId == profileId).ToListAsync();
        }

        public async Task<ConnectionPending> SendConnectionPendingAsync(Profile senderProfile, int receiverProfileId)
        {
            var connectionPending = new ConnectionPending
            {
                ReceiverId = receiverProfileId,
                SenderId = senderProfile.Id,
                SenderPhoto = senderProfile.ProfilePicture,
                SenderName = senderProfile.UserName
            };

            var profileToReceive = await _profileService.GetProfileByProfileId(receiverProfileId);

            if (profileToReceive != null)
            {
                await _ctx.ConnectionPendings.AddAsync(connectionPending);
                profileToReceive.ConnectionPendings.Add(connectionPending);
                await _ctx.SaveChangesAsync();

                return connectionPending;
            }

            throw new Exception("Could not found profile to send connection request");
        }

    }
}
