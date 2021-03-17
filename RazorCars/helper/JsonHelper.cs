using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorCars.helper
{
    public static class JsonHelper<T> where T : class
    {
        public async static Task SaveToJsonAsync(ICollection<T> data, String filename)
        {
            using (FileStream outfile = File.Create(filename))
            {
                await JsonSerializer.SerializeAsync(outfile,
                    data,
                    new JsonSerializerOptions()
                    {
                        WriteIndented = true
                    });
            }
        }


        public async static Task<ICollection<T>> ReadFromJson(string filename)
        {
            if (!File.Exists(filename))
            {
                return new List<T>();
            }

            using (FileStream inputfile = File.OpenRead(filename))
            {
                return await JsonSerializer.DeserializeAsync<List<T>>(inputfile);
            }


        }

    }
}
