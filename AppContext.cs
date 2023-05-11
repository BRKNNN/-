using System;
using System.Data.Entity;

public class Class1
{
	public DbSet<User> Регистрация/авторизация { get; set }

	public AppContext() : base("Entities") { }
	

	
}
