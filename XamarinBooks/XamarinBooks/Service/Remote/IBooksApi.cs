using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinBooks.Models;

namespace XamarinBooks.Service.Remote
{
	public interface IBooksApi
	{
		[Get("/volumes?q={query}&maxResults=20&Type=books&startIndex={indice}")]
		[Headers("Content-Type: application/json")]
		Task<BookVolume> GetBookVolume(string query, int indice);
	}
}
