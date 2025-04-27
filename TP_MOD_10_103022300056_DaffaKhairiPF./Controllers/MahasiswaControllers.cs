using System;
using Microsoft.AspNetCore.Mvc;
using TP_MOD_10_103022300056_DaffaKhairiPF_.Models;

namespace TP_MOD_10_103022300056_DaffaKhairiPF_.Controllers
{
	public class MahasiswaControllers
	{
        [Route("api/[controller]")]
        [ApiController]
        public class MahasiswaController : ControllerBase
        {
            // Data statis mahasiswa (anggota kelompok)
            private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Daffa Khairi", Nim = "103022300056" }, // Anda sebagai pertama
            new Mahasiswa { Nama = "LeBron James", Nim = "1302000001" },
            new Mahasiswa { Nama = "Stephen Curry", Nim = "1302000002" }
        };

            // GET: api/mahasiswa
            [HttpGet]
            public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
            {
                return Ok(mahasiswaList);
            }

            // GET api/mahasiswa/{index}
            [HttpGet("{index}")]
            public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
            {
                if (index < 0 || index >= mahasiswaList.Count)
                {
                    return NotFound("Index tidak ditemukan");
                }
                return Ok(mahasiswaList[index]);
            }

            // POST api/mahasiswa
            [HttpPost]
            public ActionResult PostMahasiswa([FromBody] Mahasiswa newMahasiswa)
            {
                if (newMahasiswa == null || string.IsNullOrEmpty(newMahasiswa.Nama) || string.IsNullOrEmpty(newMahasiswa.Nim))
                {
                    return BadRequest("Nama dan Nim harus diisi");
                }

                mahasiswaList.Add(newMahasiswa);
                return CreatedAtAction(nameof(GetMahasiswaByIndex), new { index = mahasiswaList.Count - 1 }, newMahasiswa);
            }

            // DELETE api/mahasiswa/{index}
            [HttpDelete("{index}")]
            public ActionResult DeleteMahasiswa(int index)
            {
                if (index < 0 || index >= mahasiswaList.Count)
                {
                    return NotFound("Index tidak ditemukan");
                }

                mahasiswaList.RemoveAt(index);
                return NoContent();
            }
        }
    }
}

