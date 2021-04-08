using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorCars.helper
{
    /// <summary>
    /// This class have two methods one for reading json-file and one for writing to a json-file 
    /// </summary>
    /// <typeparam name="T">Can be any class but not simple types</typeparam>
    public  class JsonHelper<T> where T : class
    {
        /// <summary>
        /// Save an objekt to a file in json format
        /// </summary>
        /// <param name="data">the collection to be saved</param>
        /// <param name="filename">the full filename of the json-file</param>
        /// <returns>A task i.e. wait for the saving to be done</returns>
        public async  Task SaveToJsonAsync(ICollection<T> data, String filename)
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


        public async  Task<ICollection<T>> ReadFromJson(string filename)
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
