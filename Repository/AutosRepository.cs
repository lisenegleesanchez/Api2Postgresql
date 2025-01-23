using Api2Postgresql.Context;
using Api2Postgresql.Models;
using Microsoft.EntityFrameworkCore;

namespace Api2Postgresql.Repository
{
    public class AutosRepository (AutosDbContext context): AutosInterface
    {
        public async Task<bool> CreateAsync(Autos auto)
        {
            context!.MarcaAutos.Add(auto);
            var result = await context.SaveChangesAsync();
            return result > 0;

            //throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var getAutos = await context.MarcaAutos.FirstOrDefaultAsync(_ => _.Id == id);

            if (getAutos != null)
            {

                context.MarcaAutos.Remove(getAutos);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
        
            return false;
        }

        public async Task<IEnumerable<Autos>> GetAllAsync() => await context!.MarcaAutos.ToListAsync();



        public async Task<Autos> GetByAsync(int id)
        {
            return await context!.MarcaAutos!.FirstOrDefaultAsync(_ => _.Id == id);
        }



        public async Task<bool> UpdateAsync(Autos auto)
        {
            var getAutos = await context.MarcaAutos.FirstOrDefaultAsync(_ => _.Id == auto.Id);

            if (getAutos != null) {

                getAutos.Marca =auto.Marca;
                getAutos.Modelo = auto.Modelo;
                getAutos.NroPuertas = auto.NroPuertas;
                getAutos.Ano = auto.Ano;
                getAutos.Color = auto.Color;
                var result = await context.SaveChangesAsync();
                return result > 0;
                // throw new NotImplementedException();

            }
            return false;
        }
    }

}
