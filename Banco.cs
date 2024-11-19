/*
 * Creado por SharpDevelop.
 * Usuario: SALAFAR
 * Fecha: 27/10/2022
 * Hora: 10:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 */

using System;
using System.Collections;

namespace Proyecto_Banco
{
	public class Banco{
		//atributos
		private string nomBan;
		private ArrayList cuentas;
		private ArrayList clientes;
		//private ArrayList clienteMasDeUnaCuenta;
		//constructor
		public Banco(string nomBan){
			this.nomBan=nomBan;
			cuentas=new ArrayList();
			clientes=new ArrayList();
			//clienteMasDeUnaCuenta=new ArrayList();
		}
		//propiedades
		public ArrayList Cuentas{
			get{
				return cuentas;
			}
		}
		public ArrayList Clientes{
			get{
				return clientes;
			}	
		}
		/*public ArrayList ClienteMasDeUnaCuenta{
			get{
				return clienteMasDeUnaCuenta;
			}
		}*/
		public string NomBan{
			get{return nomBan;}
			set{nomBan=value;}
		}
		//metodos
		public void agregarCuenta(Cuenta c){
			cuentas.Add(c);
		}
		public void agregarCliente(Cliente c){
			clientes.Add(c);
		}

		public void depositarDinero(int numCuent,double dine){
			bool t=false;
			foreach(Cuenta cc in cuentas){
				if(cc.NumCuent==numCuent){
					cc.Saldo+=dine;
					t=true;
					break;					
				}
			}
			if(!t){
				Console.WriteLine("No tiene una cuenta");
				Console.WriteLine("");
			}
		}
		public void extraccion(int numCuent,double saldo){
			double total=0;
			bool t=false;
			foreach(Cuenta cc in cuentas){
				if(cc.NumCuent==numCuent){
					total=cc.Saldo-saldo;
					if (total>=0){
					t=true;
					cc.Saldo=total;
					break;	
					}
					throw new SaldoInsuficienteExeption();	
				}
			}
			if(!t){
				Console.WriteLine("No tiene una cuenta");
				Console.WriteLine("");
			}
		}
		public void eliminarCliente(int x){
			clientes.RemoveAt(x);
		}
		/*public void eliminarClienteMasDeUnaCuenta(int x){
			clienteMasDeUnaCuenta.RemoveAt(x);
		}*/
		
		public void eliminarCuenta(int x){
			cuentas.RemoveAt(x);
		}
		/*public void verClientesConMasDeUnaCuenta(){
			if(clienteMasDeUnaCuenta.Count>0){
				Console.WriteLine("");
				Console.WriteLine("Lista de cliente con mas de un cuenta:");
				Console.WriteLine("");
				foreach(Cliente c in clienteMasDeUnaCuenta){
					Console.WriteLine("Titular: {0} DNI: {1}",c.NomApe,c.Dni);
					foreach(Cuenta cc in cuentas){
						if(c.Dni==cc.Dni){
							Console.WriteLine("Cuenta N�: {0} Saldo: {1}",cc.NumCuent,cc.Saldo);
						}
					}
				}
			}else{
				Console.WriteLine("");
				Console.WriteLine("No hay clientes com mas de una cuenta");
				Console.WriteLine("");
			}
		}*/
		public void verCuentas(){
			Console.WriteLine("");
			Console.WriteLine("Lista de cuentas:");
			Console.WriteLine("");
			foreach(Cuenta c in cuentas){
				Console.WriteLine("N� de cuenta: {0} Titular: {1} DNI: {2} Saldo: {3}",c.NumCuent,c.NomApe,c.Dni,c.Saldo);
			}
		}
		public void verClientes(){
			Console.WriteLine("");
			Console.WriteLine("Lista de clientes:");
			Console.WriteLine("");
			foreach(Cliente c in clientes){
				Console.WriteLine("Nombre y Apellido: {0}, DNI: {1}, Direccion: {2}, Telefono:{3}, Mail:{4}",c.NomApe,c.Dni,c.Direccion,c.Telefono,c.Mail);
				Console.WriteLine("");
			}
		}

	}
}