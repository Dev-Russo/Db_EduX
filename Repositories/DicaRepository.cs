using EduX_API.Context;
using EduX_API.Domains;
using EduX_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX_API.Repositories
{
    public class DicaRepository : IDicaRepository
    {
        private readonly EduXContext _ctx;
        public DicaRepository()
        {
            _ctx = new EduXContext();
        }
        public void Adicionar(Dica dica)
        {
            try
            {
                _ctx.Dica.Add(dica);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Dica BuscarPorId(Guid Id)
        {
            try
            {
                return _ctx.Dica.Find(Id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Dica dica)
        {
            try
            {
                //atribuição de objeto
                Dica dicaContexto = BuscarPorId(dica.IdDica);
                if (dicaContexto == null)
                {
                    throw new Exception("Dica não encontrada");
                }
                //Atribuição de propriedade = pega as alterações do objeto para o Banco de dados
                dicaContexto.Texto = dica.Texto;
                dicaContexto.Imagem = dica.Imagem;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Dica> Listar()
        {
            try
            {
                return _ctx.Dica.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid Id)
        {
            try
            {
                //Atribuição por objeto
                Dica dica = BuscarPorId(Id);
                if (dica == null)
                {
                    throw new Exception("Dica não existe");
                }
                _ctx.Dica.Remove(dica);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}