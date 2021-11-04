using BankGateWay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankGateWay.Services
{
    public class EmployeeLoginService
    {
        private readonly EmployeeContext _context;

        public EmployeeLoginService(EmployeeContext context)
        {
            _context = context;
        }
        public EmployeeLoginDto Register(EmployeeLoginDto loginDto)
        {
            try
            {
                if (_context.BankEmployee.Where(e => e.Email == loginDto.Email).Any())
                {
                    return null;
                }
                else
                {
                    using var hmac = new HMACSHA512();
                    var PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                    var PasswordSalt = hmac.Key;
                    EmployeeLogin login = new EmployeeLogin()
                    {
                        Email = loginDto.Email,
                        PasswordHash = PasswordHash,
                        PasswordSalt = PasswordSalt,
                        Address = loginDto.Address,
                        Phone = loginDto.Phone,
                        Name=loginDto.Name
                    };
                    _context.BankEmployee.Add(login);
                    _context.SaveChanges();
                    loginDto.Password = "";
                    return loginDto;
                }
            }
           catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public EmployeeLoginDto Login(EmployeeLoginDto loginDto)
        {
            try
            {
                EmployeeLogin dto = null;
                dto = _context.BankEmployee.FirstOrDefault(e=>e.Email==loginDto.Email);
                if (dto == null)
                {
                    return null;
                }
                else
                {
                    using var hmac = new HMACSHA512(dto.PasswordSalt);
                    var PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                    for (int i = 0; i < PasswordHash.Length; i++)
                    {
                        if (PasswordHash[i] != dto.PasswordHash[i])
                            return null;
                    }
                    loginDto.EmployeeID = dto.EmployeeID;
                    loginDto.Name = dto.Name;
                    loginDto.Password = "";
                    return loginDto;
                }
                    
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
