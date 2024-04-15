using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Services.Validators;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        // Verifica los del usuario en la lista _users
        private List <Usuario> _users = new List<Usuario>
        { 
            new Usuario{ Username = "Admin", Password = "Password"}
        };

        private readonly IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



       
        public async Task<string> Login(Usuario user)
        {
            // Verifica las credenciales del usuario en la lista _users
            var LoginUser = _users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            // Si las credenciales no son válidas, devuelve una cadena vacía
            if (LoginUser == null)
            {
                return string.Empty;
            }

            // Crea un token handler para manipular tokens JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            // clave secreta para firmar el token
            var key = Encoding.ASCII.GetBytes("c2c3111663e00afe901d9c00ab169d36");

            // Descriptor de token que incluye la identidad del usuario, el tiempo de expiración y la firma
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username) // Agrega el nombre de usuario como un Claim
                }),
                Expires = DateTime.UtcNow.AddMinutes(30), // Expiración del token en 30 minutos
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // Firma el token con la clave secreta
            };

            // Crea un token JWT utilizando el descriptor de token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Convierte el token en una cadena para enviar al cliente
            string userToken = tokenHandler.WriteToken(token);

            // Devuelve el token JWT
            return userToken;
        }


         public async Task<Usuario> CreateUsuario(Usuario newUsuario)
        {
            UsuarioValidators validator = new();

            var validationResult = await validator.ValidateAsync(newUsuario);
            if (validationResult.IsValid)
            {
                await _unitOfWork.UsuarioRepository.AddAsync(newUsuario);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newUsuario;
        }

        
        public async Task DeleteUsuario(string usuarioId)
        {
            Usuario usuario = await _unitOfWork.UsuarioRepository.GetByIdAsync(int.Parse(usuarioId));
            _unitOfWork.UsuarioRepository.Remove(usuario);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _unitOfWork.UsuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _unitOfWork.UsuarioRepository.GetByIdAsync(id);
        }

        public async  Task<Usuario> UpdateUsuario(int usuarioToBeUpdatedId, Usuario newUsuarioValues)
        {
            UsuarioValidators UsuarioValidators = new();
            
            var validationResult = await UsuarioValidators.ValidateAsync(newUsuarioValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Usuario UsuarioToBeUpdated = await _unitOfWork.UsuarioRepository.GetByIdAsync(usuarioToBeUpdatedId);

            if (UsuarioToBeUpdated == null)
                throw new ArgumentException("Invalid User ID while updating");

            UsuarioToBeUpdated.Username = newUsuarioValues.Username;
            UsuarioToBeUpdated.Password = newUsuarioValues.Password;
          

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.UsuarioRepository.GetByIdAsync(usuarioToBeUpdatedId);
        }

    }
}