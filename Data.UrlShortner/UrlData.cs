using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.UrlShortner
{
    public class UrlData
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }

		[Required]
		public string OriginalURL { get; set; }

		[Required]
		public string ShortenedURL { get; set; }

		[Required]
		public string Token { get; set; }

		[Required]
		public int Visits { get; set; } = 0;

		[Required]
		public DateTime Created { get; set; } = DateTime.Now;
	}
}
