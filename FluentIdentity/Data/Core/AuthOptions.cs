﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentIdentity.Data.Core
{
	public class AuthOptions
	{
		public const string ISSUER = "MyAuthServer"; // издатель токена
		public const string AUDIENCE = "http://localhost:58644/"; // потребитель токена
		const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
		public const int LIFETIME = 20; // время жизни токена - 1 минута
		public static SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
		}

	}
}
