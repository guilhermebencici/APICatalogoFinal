﻿using APICatalogoFinal.Context;
using APICatalogoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogoFinal.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{

    private readonly AppDbContext _context;
    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    //Utilizao o ActionResult porque assim posso retornar mais que um tipo, neste caso: Uma lista ou o método Action em si (NotFound)
    public ActionResult<IEnumerable<Produto>> Get() //IEnumerable: É ma interface de leitura. Permite adiar a execução (trabalha por demanda)
    {
        var produtos = _context.Produtos.ToList();
        if (produtos is null)
        {
            return NotFound("Produtos não encontrados");// equivalente ao 404
        }
        return produtos;
    }

    [HttpGet("{id:int}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        if (produto is null)
        {
            return NotFound("Produto não encontrado...");
        }
        return produto;
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto is null)
            return BadRequest();

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterProduto",
            new { id = produto.ProdutoId }, produto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (id != produto.ProdutoId)
        {
            return BadRequest();
        }

        _context.Entry(produto).State = EntityState.Modified;//persistindo a entidade
        _context.SaveChanges();

        return Ok(produto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        //var produto = _context.Produtos.Find(id); o find() tenta localizar na memória

        if (produto is null)
        {
            return NotFound("Produto não localizado...");
        }
        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return Ok(produto);
    }
}