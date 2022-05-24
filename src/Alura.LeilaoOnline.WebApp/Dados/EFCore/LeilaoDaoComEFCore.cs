using System.Linq;
using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class LeilaoDaoComEFCore : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDaoComEFCore()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Categoria> ListarCategorias()
        {
            return _context.Categorias.ToList();
        }

        public IIncludableQueryable<Leilao, Categoria> ListarLeiloes()
        {
            return _context.Leiloes.Include(l => l.Categoria);
        }

        public Leilao ListarLeilaoPorId(int id)
        {
            return _context.Leiloes.FirstOrDefault(l => l.Id == id);
        }

        public void IncluirLeilao(Leilao model)
        {
            _context.Leiloes.Add(model);
            _context.SaveChanges();
        }

        public void AtualizarLeilao(Leilao model)
        {
            _context.Leiloes.Update(model);
            _context.SaveChanges();
        }

        public void RemoverLeilao(Leilao model)
        {
            _context.Leiloes.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<Leilao> PesquisarPorTermo(string termo)
        {
            return _context.Leiloes
                .Include(l => l.Categoria)
                .Where(l => string.IsNullOrWhiteSpace(termo) || 
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) || 
                    l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
        }

    }
}
