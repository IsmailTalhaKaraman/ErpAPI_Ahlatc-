using AutoMapper;
using ErpAPI.Api.Aspects;
using ErpAPI.Api.Validation.FluentValidation;
using ErpAPI.Busines.Abstract;
using ErpAPI.EEntity.DTO.UserDTO;
using ErpAPI.EEntity.Poco;
using ErpAPI.EEntity.Result;
using ErpAPI.Helper.CustomException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ErpAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("/Users")]
        [ProducesResponseType(typeof(Sonuc<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            List<UserResponseDTO> userDTOList = new();
            foreach (var user in users)
            {
              
                userDTOList.Add(_mapper.Map<UserResponseDTO>(user));
            }
            return Ok(Sonuc<List<UserResponseDTO>>.SuccesWithData(userDTOList));
        }

        [HttpGet("/User/{ID}")]
        [ProducesResponseType(typeof(Sonuc<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUser(int ID)
        {
            var user = await _userService.GetAsync(q => q.ID == ID);

            if (user != null)
            {
                

                UserResponseDTO userDTO = _mapper.Map<UserResponseDTO>(user);
                return Ok(Sonuc<UserResponseDTO>.SuccesWithData(userDTO));
            }
            return NotFound(Sonuc<UserResponseDTO>.SuccesNoDataFound());

        }

        [HttpPost("/AddUser")]
        [ValidationFilter(typeof(UserValidator))]
        public async Task<IActionResult> AddUser(UserRequestDTO userRequestDTO)
        {

            UserValidator userValidator = new UserValidator();

            if (userValidator.Validate(userRequestDTO).IsValid)
            {
                User user = _mapper.Map<User>(userRequestDTO);
                await _userService.AddAsync(user);
                UserResponseDTO userResponseDTO = _mapper.Map<UserResponseDTO>(user);
                return Ok(Sonuc<UserResponseDTO>.SuccesWithData(userResponseDTO));
            }
            else
            {
                List<string> ValidatonMessages = new List<string>();
                for (int i = 0; i < userValidator.Validate(userRequestDTO).Errors.Count; i++)
                {
                    ValidatonMessages.Add(userValidator.Validate(userRequestDTO).Errors[i].ErrorMessage);
                }
                throw new FieldValidationException(ValidatonMessages);



            }


        }
    }
}