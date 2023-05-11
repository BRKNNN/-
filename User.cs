using System;

public class Class1
{
	private int ID { get; set; }
	private string Login, Password, Data_birth, Phone;

	public Class1() { }

	public User(string Login, string Password, string Data_birth, string Phone)
    {
		this.Login = Login;
		this.Password = Password;
		this.Data_birth = Data_birth;
		this.Phone = Phone;
    }   
	
}
