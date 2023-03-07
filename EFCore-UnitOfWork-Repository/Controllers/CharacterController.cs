using EFCoreRelationshipsTutorial.DTO.CharacterDTO;
using EFCoreRelationshipsTutorial.DTO.UserDTO;
using EFCoreRelationshipsTutorial.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationshipsTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public CharacterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add-character")]
        public async Task AddCharacter(AddCharacterDTO addCharacterDTO)
        {
            try
            {
                Character character = new Character() { Name = addCharacterDTO.Name };
                var user = await _unitOfWork.UserRepository.Get(addCharacterDTO.UserId);
                if (user.Characters == null)
                {
                    user.Characters = new List<Character> { character };
                }
                else
                {
                    user.Characters.Add(character);
                }

                await _unitOfWork.Save();
            }
            catch (Exception)
            {

                BadRequest();
            }

     

        }


        [HttpDelete("delete-character")]
        public async Task DeleteCaracter(int characterId)
        {
            try
            {

                await _unitOfWork.CharacterRepository.Delete(characterId);
                await _unitOfWork.Save();
            }
            catch (Exception)
            {
                BadRequest();
            } 
        }
        [HttpGet("getAll-character")]
        public async Task<ActionResult<List<Character>>> GetAllCharacter()
        {
            try
            {
                List<Character> characters = await _unitOfWork.CharacterRepository.GetAll();
                return characters;
            }
            catch (Exception)
            {

                return BadRequest();
            }
      
        }


    }
}