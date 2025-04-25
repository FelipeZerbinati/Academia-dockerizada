using Academia10.Domain.DTO;
using Academia10.Domain.Interfaces.Repository;
using Academia10.Domain.Interfaces.Services;
using Academia10.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia10.Application.Service;

public class AcademiaService(IUnitOfWork unitOfWork) : IAcademiaService
{
    public async Task<ResultData<Academia>> CreateAcademia(Academia newAcademia)
    {
        var result = new ResultData<Academia>();
        try
        {
            var id = unitOfWork.Academia10Repository.Insert(newAcademia);
            newAcademia.Id = id;
            await unitOfWork.CommitAsync();
            result.Success = true;
            result.Data = newAcademia;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorDescription = $"Erro inesperado: {ex.Message}";
        }
        finally
        {
            if (!result.Success)
            {
                result.Data = null;
            }
        }
        return result;
    }

    public async Task<ResultData<bool>> DeleteAcademia(Guid id)
    {
        var result = new ResultData<bool>();
        try
        {
            var academia = await unitOfWork.Academia10Repository.GetAsync(false, null, a => a.Id == id);
            unitOfWork.Academia10Repository.Delete(academia);
            await unitOfWork.CommitAsync();
            result.Success = true;
            result.Data = true;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorDescription = $"Erro inesperado: {ex.Message}";
        }
        finally
        {
            if (!result.Success)
            {
                result.Data = false;
            }
        }
        return result;
    }

    public async Task<ResultData<Academia>> GetAcademiaById(Guid id)
    {
        var result = new ResultData<Academia>();
        try
        {
            var academia = await unitOfWork.Academia10Repository.GetByIdAsync(id);
            result.Data = academia;
            result.Success = true;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorDescription = $"Erro inesperado: {ex.Message}";
        }
        finally
        {
            if (!result.Success)
            {
                result.Data = new Academia();
            }
        }
        return result;
    }

    public async Task<ResultData<List<Academia>>> GetAcademias(int page, int perPage)
    {
        var result = new ResultData<List<Academia>>();
        try
        {
            var academias = await unitOfWork.Academia10Repository.GetFilteredAsync(
                 tracking: false,
                predicate: x => true,
                orderBy: null,
                page: page,
                perPage: perPage

                );
            result.Data = academias;
            result.Success = true;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorDescription = $"Erro inesperado: {ex.Message}";
        }
        finally
        {
            if (!result.Success)
            {
                result.Data = new List<Academia>();
            }
        }
        return result;
    }

    public async Task<ResultData<Academia>> UpdateAcademia(Guid id, Academia updatedAcademia)
    {
        var result = new ResultData<Academia>();
        try
        {
            var academia = await unitOfWork.Academia10Repository.GetAsync(false, null, a => a.Id == id);
            if (academia == null)
            {
                result.Success = false;
                result.ErrorDescription = "Gym does not exist";
                return result;
            }
            academia.Nome = updatedAcademia.Nome;
            unitOfWork.Academia10Repository.Update(academia);
            await unitOfWork.CommitAsync();
            result.Success = true;
            result.Data = updatedAcademia;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorDescription = $"Erro inesperado: {ex.Message}";
        }
        finally
        {
            if(!result.Success)
            {
                result.Data = new Academia();
            }
        }
        return result;
    }
}
