using EFCoreRelationshipsTutorial;
using EFCoreRelationshipsTutorial.DTO.CharacterDTO;
using EFCoreRelationshipsTutorial.DTO.WeaponDTO;
using EFCoreRelationshipsTutorial.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_UnitOfWork_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public WeaponController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost("add-weapon")]
        public async Task AddWeapon(AddWeaponDTO addWeaponDTO)
        {
            try
            {
                var weapon= new Weapon() { Name = addWeaponDTO.Name,Damage=addWeaponDTO.Damage };
                var character = await _unitOfWork.CharacterRepository.Get(addWeaponDTO.CharaterId);
                character.Weapon = weapon;

                await _unitOfWork.Save();
            }
            catch (Exception)
            {

                BadRequest();
            }



        }


        [HttpGet("getBy-params")]
        public async Task<ActionResult<List<Weapon>>> GetByParams(string name ,int damage)
        {
            try
            {
                var weapons = await _unitOfWork.WeaponRepository.GetByNameDamage(name,damage);
                return weapons;
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet("getOrderByDesc")]
        public async Task<ActionResult<List<Weapon>>> GetOrderByDesc()
        {
            try
            {
                var weapons = await _unitOfWork.WeaponRepository.GetSortByDamageDesc();
                return weapons;
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet("getOrderBy")]
        public async Task<ActionResult<List<Weapon>>> GetOrderBy()
        {
            try
            {
                var weapons = await _unitOfWork.WeaponRepository.GetSortByDamage();
                return weapons;
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet("getAll-weapon")]
        public async Task<ActionResult<List<Weapon>>> GetAllCharacter()
        {
            try
            {
               var  weapons= await _unitOfWork.WeaponRepository.GetAll();
                return weapons;
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

    }
}
