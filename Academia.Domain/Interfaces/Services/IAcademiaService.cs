using Academia10.Domain.DTO;
using Academia10.Domain.Models;

namespace Academia10.Domain.Interfaces.Services;

public interface IAcademiaService
{
    Task<ResultData<Academia>> CreateAcademia(Academia newAcademia);
    Task<ResultData<List<Academia>>> GetAcademias(int page, int perPage);
    Task<ResultData<Academia>> GetAcademiaById(Guid id);
    Task<ResultData<Academia>> UpdateAcademia(Guid id, Academia updatedAcademia);
    Task<ResultData<bool>> DeleteAcademia(Guid id);
}
