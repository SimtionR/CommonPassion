using CommonPassion_Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IConnectionService
    {
        Task<ConnectionPending> SendConnectionPendingAsync(Profile sendeerProfile, int receiverProfileId);
        Task<ConnectionPending> GetConnectionPendingByIdAsync(int connectionPendingId);
        Task<IEnumerable<ConnectionPending>> GetConnectionsPendingByProfileIdAsync(int profileId);

        Task<ResponsePending> AcceptConnectionPendingAsync(ResponsePending responsePending);
        Task<ResponsePending> DeclineConnectionPendingAsync(ResponsePending responsePending);
        Task<ResponsePending> GetResponsePendingByIdAsync(int connectionPendingId);
        Task<IEnumerable<ResponsePending>> GetResponsePendingsByProfileIdAsync(int profileId);

        Task<bool> DeleteConnectinPendingAsync(int conncetionPending);
        Task CreateConnectionAsync(ResponsePending acceptedPending);
        Task<Connection> GetConnectionByIdAsync(int connectionId);
        Task<IEnumerable<Connection>> GetConnectionsByProfileId(int profileId);
        Task<bool> DeleteConnectionByIdAsync(int connectionId);
    }
}
