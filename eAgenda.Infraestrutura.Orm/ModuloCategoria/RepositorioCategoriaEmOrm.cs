//using eAgenda.Dominio.ModuloContato;

//namespace eAgenda.Infraestrutura.Orm.ModuloContato;

//public class RepositorioContatoEmOrm : IRepositorioContato
//{
//    private readonly AppDbContext context;

//    public RepositorioContatoEmOrm(AppDbContext context)
//    {
//        this.context = context;
//    }

//    public void CadastrarRegistro(Contato novoRegistro)
//    {
//        context.Contatos.Add(novoRegistro);

//        context.SaveChanges();
//    }

//    public bool EditarRegistro(Guid idRegistro, Contato registroEditado)
//    {
//        var registroOriginal = SelecionarRegistroPorId(idRegistro);

//        if (registroOriginal is null)
//            return false;

//        registroOriginal.AtualizarRegistro(registroEditado);

//        context.SaveChanges();

//        return true;
//    }

//    public bool ExcluirRegistro(Guid idRegistro)
//    {
//        var registro = SelecionarRegistroPorId(idRegistro);

//        if (registro is null)
//            return false;

//        context.Contatos.Remove(registro);

//        context.SaveChanges();

//        return true;
//    }

//    public Contato? SelecionarRegistroPorId(Guid idRegistro)
//    {
//        return context.Contatos.Find(idRegistro);
//    }

//    public List<Contato> SelecionarRegistros()
//    {
//        return context.Contatos.ToList();
//    }
//}