using EFCoreRelationshipsTutorial.DTO.UserDTO;
using EFCoreRelationshipsTutorial.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationshipsTutorial.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost("add-user")]
    public async Task AddUser(AddUserDTO addUserDTO)
    {
        try
        {

            User user = new User() { Username = addUserDTO.Name };
            await _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.Save();

        }
        catch (Exception)
        {

            BadRequest();
        }
    }




    [HttpGet("get-user")]

    public async Task<ActionResult<User>> GetUser(int userId)
    {

        try
        {
            return await _unitOfWork.UserRepository.Get(userId);

        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete-user")]

    public async Task DeleteUser(int userId)
    {
        await _unitOfWork.BeginTransaction();
        try
        {

            var user = await _unitOfWork.UserRepository.Get(userId);
            if (user == null)
            {
                throw new Exception();
            }
            if (user.Characters != null)
            {

                user.Characters.Clear();
                await _unitOfWork.Save();
            }


            await _unitOfWork.UserRepository.Delete(userId);
            await _unitOfWork.Save();
        }
        catch (Exception)
        {
            await _unitOfWork.RollBackTransaction();
            BadRequest();
        }
        finally
        {
            await _unitOfWork.Commit();
        }

    }
    [HttpPut("updata-user")]

    public async Task UpdataUser(UpdateUserDTO updateUserDTO)
    {
        try
        {
            await _unitOfWork.UserRepository.Update(new User() { Username = updateUserDTO.Name, Id = updateUserDTO.UserId });
            await _unitOfWork.Save();
        }
        catch (Exception)
        {

            BadRequest();
        }

    }

    [HttpGet("getAll-user")]

    public async Task<ActionResult<List<User>>> GetAllUser()
    {
        try
        {
            List<User> users = await _unitOfWork.UserRepository.GetAll();
            return users;
        }
        catch (Exception)
        {

            return BadRequest();
        }

    }
}
