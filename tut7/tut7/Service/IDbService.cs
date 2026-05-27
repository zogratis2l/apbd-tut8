using tut7.DTOs;
using tut7.Models;
using tut7.DTOs;

namespace tut7.Service;

public interface IDbService
{
    public Task<List<GetAllPCsDTO>> GetAllPCs();
    public Task<GetPCDTO> GetPC(int id);

    public Task<PC> CreatePC(CreatePCDTO dto);

    public Task UpdatePC(UpdatePCDTO dto, int id);

    public Task DeletePC(int id);
}