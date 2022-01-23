using System.Threading.Tasks;
using PlateformService.Dtos;

namespace PlateformService.SyncDataServices.Http
{
    public interface ICommandDataService
    {
        Task SendPlatformToCommand(PlatformReadDto platform);
    }
}