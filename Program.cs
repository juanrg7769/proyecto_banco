/*
 * Creado por SharpDevelop.
 * Usuario: SALAFAR
 * Fecha: 27/10/2022
 * Hora: 10:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 * 
 * Un banco tiene nombre y un conjunto de cuentas bancarias. De cada cuenta se conoce  su nro, apellido y dni del cliente 
* titular y saldo. De los clientes la informaci�n relevante es su nombre y apellido, dni, direcci�n, tel�fono de contacto y 
* mail.
Se deber� desarrollar una aplicaci�n, utilizando las clases que crea necesarias, que resuelva las funcionalidades que se
muestran en el siguiente men�:
a)	Agregar una cuenta al banco. Si el cliente es nuevo (no tiene otra cuenta previa) se debe dar de alta en la lista de 
clientes y debe efectuar un dep�sito de dinero en la caja nueva.
b)	Eliminar una cuenta y si no existe ninguna otra cuenta del mismo titular, dar de baja tambi�n al cliente.
c)	Listado de clientes que tienen m�s de una cuenta , indicando nro de cuenta y saldo de cada una.
d)	Realizar una extracci�n. En caso de no poseer saldo suficiente se debe levantar una excepci�n que indique lo sucedido 
(�Saldo insuficiente�)
e)	Depositar dinero en una cuenta dada.
f)	Transferir dinero entre dos cuentas. Validar existencia de saldo en la cuenta origen.
g)	Listado de cuentas
h)	Listado de clientes

 */
using System;
using System.Collections;
namespace Proyecto_Banco
{
	public class SaldoInsuficienteExeption: Exception{}
	class Program
	{
		public static void Main(string[] args)
		{	
			ArrayList mas=new ArrayList();
			string nomB="Frances",nomApe="juan galiano",dni="33490343",dire="Monteverde 6469, F. Varela",mail="juanrg6977@gmail.com",bucle="Si",elegir;
			int tel=1161862278,cuenta=1;
			double saldo=100000;
			Banco b=new Banco(nomB);
			//creo 2 clientes, juan y lucrecia, y sus respectivas cuentas
			Cliente j=new Cliente(nomApe,dni,dire,tel,mail);
			b.agregarCliente(j);
			Cuenta cj=new Cuenta(cuenta,saldo,nomApe,dni);
			b.agregarCuenta(cj);
			cuenta++;
			nomApe="lucrecia medina";dni="32404133";dire="El Surubi 469, Ezpeleta";mail="lopezlucre845@hotmail.com";tel=1142132723;
			Cliente l=new Cliente(nomApe,dni,dire,tel,mail);
			b.agregarCliente(l);
			saldo=50000;
			Cuenta cl=new Cuenta(cuenta,saldo,nomApe,dni);
			b.agregarCuenta(cl);
			cuenta++;
			Console.WriteLine("Bienvenidos al banco "+nomB);
			Console.WriteLine("");
			while(bucle=="Si"){
				Console.Clear();
				Console.WriteLine("Ingrese una opcion del 1 al 9:");
				Console.WriteLine("");
				Console.WriteLine("1. Agregar una cuenta al banco.");
				Console.WriteLine("2. Eliminar una cuenta.");
				Console.WriteLine("3. Listado de clientes que tienen m�s de una cuenta.");
				Console.WriteLine("4. Realizar una extracci�n.");
				Console.WriteLine("5. Depositar dinero en una cuenta dada.");
				Console.WriteLine("6. Transferir dinero entre dos cuentas.");
				Console.WriteLine("7. Listado de cuentas.");
				Console.WriteLine("8. Listado de clientes.");
				Console.WriteLine("9. Salir.");
				elegir=Console.ReadLine();
				switch(elegir){
						case "1":
						Console.Clear();
							Console.WriteLine("Ustes ya es cliente? s/n");
							char o=char.Parse(Console.ReadLine());
							switch(o){
								case 'n':
									Console.WriteLine("Ingrese nombre y apellido:");
									nomApe=Console.ReadLine();
									Console.WriteLine("Ingrese dni:");
									dni=Console.ReadLine();
									Console.WriteLine("Ingrese direccion:");
									dire=Console.ReadLine();
									Console.WriteLine("Ingrese telefono");
									tel=int.Parse(Console.ReadLine());
									Console.WriteLine("Ingrese mail:");
									mail=Console.ReadLine();
									Cliente c=new Cliente(nomApe,dni,dire,tel,mail);
									bool ocupado= false;
									foreach (Cliente cc in b.Clientes){
										if (c.Dni==cc.Dni){
												ocupado=true;
												Console.WriteLine("Usted ya es cliente");
												break;
											}
										}
									if (!ocupado){
										b.agregarCliente(c);
									Console.WriteLine("Es obligatorio depositar dinero y como minimo $10000");
									Console.WriteLine("Ingrese el dinero a depositar:");
									saldo=double.Parse(Console.ReadLine());
									bool din=false;
									while(!din){
										if(saldo>=10000){
											Cuenta cu=new Cuenta(cuenta,saldo,nomApe,dni);
											b.agregarCuenta(cu);
											int rp=0;
											foreach(Cuenta Cl in b.Cuentas){
												if(Cl.NomApe==cu.NomApe & Cl.Dni==cu.Dni)
													rp++;
											}
											if(rp==2){
												foreach(Cliente CUe in b.Clientes){
													if(CUe.NomApe==cu.NomApe & CUe.Dni==cu.Dni)
														mas.Add(CUe);
											 }
											}
											cuenta++;
											din=true;
										}else{
											Console.WriteLine("Deposito menos de $10000");
											Console.WriteLine("Ingrese el dinero a depositar:");
											saldo=double.Parse(Console.ReadLine());
										}
									}
								}
								break;
								case 's':
									Console.WriteLine("Ingrese nombre y apellido:");
									nomApe=Console.ReadLine();
									Console.WriteLine("Ingrese dni:");
									dni=Console.ReadLine();
									bool existe= false;
									foreach(Cliente cc in b.Clientes){
										if(cc.NomApe==nomApe & cc.Dni==dni){
											existe= true;
											break;
										}
									}
										if(!existe){
											Console.WriteLine("No es cliente todavia");
											Console.WriteLine("");
									}else{
									Console.WriteLine("No es obligatorio depositar dinero, si no lo hace depositara $0");
									Console.WriteLine("Va a depositar dinero? s/n");
									string dine=Console.ReadLine();
									switch(dine){
										case"s":
											Console.WriteLine("Ingrese el dinero a depositar:");
											saldo=double.Parse(Console.ReadLine());
											Cuenta cue=new Cuenta(cuenta,saldo,nomApe,dni);
											b.agregarCuenta(cue);
											int rp=0;
											foreach(Cuenta Cl in b.Cuentas){
												if(Cl.NomApe==cue.NomApe & Cl.Dni==cue.Dni)
													rp++;
											}
											if(rp==2){
												foreach(Cliente CUe in b.Clientes){
													if(CUe.NomApe==cue.NomApe & CUe.Dni==cue.Dni)
														mas.Add(CUe);
												
											 }
											}
											cuenta++;
											break;
										case"n":
											saldo=0;
											Cuenta ccue=new Cuenta(cuenta,saldo,nomApe,dni);
											b.agregarCuenta(ccue);	
											int rep=0;
											foreach(Cuenta Cl in b.Cuentas){
												if(Cl.NomApe==ccue.NomApe & Cl.Dni==ccue.Dni)
													rep++;
											}
											
											if(rep==2){
												foreach(Cliente CUe in b.Clientes){
													if(CUe.NomApe==ccue.NomApe & CUe.Dni==ccue.Dni)
														mas.Add(CUe);
												
											 }
											}
											cuenta++;
											break;
										case"":
											Console.WriteLine("Se equivoco de opcion, porque no ingreso nada");
											break;										
										default:
											Console.WriteLine("Se equivoco de opcion");
											break;											
									 }
									}
									break;
								default:
									Console.WriteLine("Se equivoco de opcion");
									break;
							}
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para ir al menu");
							Console.ReadKey(true);
							break;
						case "2":
							Console.Clear();
							Console.WriteLine("Ingrese los datos de la cuenta a borrar:");
							Console.WriteLine("Ingrese el numero de cuenta:");
							int cuent=int.Parse(Console.ReadLine());
							Console.WriteLine("Ingrese nombre y apellido:");
							nomApe=Console.ReadLine();
							Console.WriteLine("Ingrese dni:");
							dni=Console.ReadLine();
							Console.WriteLine("Ingrese el dinero de su cuenta");
							saldo=double.Parse(Console.ReadLine());
							bool exist=false;
							int x=0,z;
							foreach (Cuenta cc in b.Cuentas){
								if (cuent==cc.NumCuent & saldo==cc.Saldo & dni==cc.Dni & nomApe==cc.NomApe){
									exist=true;
									break;					
								}
								x++;
							}
							if(exist){
								b.eliminarCuenta(x);
								x=0;
								z=0;
								foreach (Cuenta cc in b.Cuentas){
									if (dni==cc.Dni & nomApe==cc.NomApe)
										z++;
								}
								if(z==0){
									foreach (Cliente cc in b.Clientes){
										if (dni==cc.Dni & nomApe==cc.NomApe)
											break;
										x++;	
									}
									b.eliminarCliente(x);
								}	
								if(z==1){
									foreach (Cliente cc in mas){
										if (dni==cc.Dni & nomApe==cc.NomApe){
											mas.RemoveAt(x);
											break;
										}
										x++;	
									}
									
								}
							}
							else
								Console.WriteLine("No existe esa cuenta");
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para ir al menu ");
							Console.ReadKey(true);
							break;
						case "3":
							Console.Clear();
							verClienteConMasDeUnaCuenta(mas,b.Cuentas);
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para al menu ");
							Console.ReadKey(true);
							break;
						case "4":
							Console.Clear();
							Console.WriteLine("Ingrese los datos de la cuenta para realizar una extraccion:");
							Console.WriteLine("Ingrese el numero de cuenta:");
							cuenta=int.Parse(Console.ReadLine());
							/*Console.WriteLine("Ingrese nombre y apellido:");
							nomApe=Console.ReadLine();
							Console.WriteLine("Ingrese dni:");
							dni=Console.ReadLine();*/
							Console.WriteLine("Ingrese el dinero a extraer");
							saldo=double.Parse(Console.ReadLine());
							//Cuenta cueen=new Cuenta(cuenta,saldo,nomApe,dni);
							try{
								b.extraccion(cuenta,saldo);
							}catch(SaldoInsuficienteExeption){
								Console.WriteLine("Saldo insufisiente");	
							}
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para ir menu ");
							Console.ReadKey(true);break;
						case "5":
							Console.Clear();
							Console.WriteLine("Ingrese los datos de la cuenta a depositar dinero");
							Console.WriteLine("Ingrese el numero de cuenta:");
							cuenta=int.Parse(Console.ReadLine());
							/*Console.WriteLine("Ingrese nombre y apellido:");
							nomApe=Console.ReadLine();
							Console.WriteLine("Ingrese dni:");
							dni=Console.ReadLine();*/
							Console.WriteLine("Ingrese el dinero a depositar:");
							saldo=double.Parse(Console.ReadLine());
							//Cuenta cuee=new Cuenta(cuenta,saldo,nomApe,dni);
							b.depositarDinero(cuenta,saldo);
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para ir al menu");
							Console.ReadKey(true);
							break;
						case "6":
							Console.Clear();
							Console.WriteLine("Ingrese los datos de la cuenta a extraer el dinero:");
							Console.WriteLine("Ingrese el numero de cuenta:");
							cuenta=int.Parse(Console.ReadLine());
							/*Console.WriteLine("Ingrese nombre y apellido:");
							nomApe=Console.ReadLine();
							Console.WriteLine("Ingrese dni:");
							dni=Console.ReadLine();*/
							Console.WriteLine("Ingrese el dinero a transferir:");
							saldo=double.Parse(Console.ReadLine());
							Cuenta cueent=new Cuenta(cuenta,saldo,nomApe,dni);
							b.extraccion(cuenta,saldo);
							Console.WriteLine("Ingrese los datos de la cuenta a depositar el dinero");
							Console.WriteLine("Ingrese el numero de cuenta:");
							cuenta=int.Parse(Console.ReadLine());
							/*Console.WriteLine("Ingrese nombre y apellido:");
							nomApe=Console.ReadLine();
							Console.WriteLine("Ingrese dni:");
							dni=Console.ReadLine();
							Cuenta cueett=new Cuenta(cuenta,saldo,nomApe,dni);*/
							b.depositarDinero(cuenta,saldo);
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para ir al menu ");
							Console.ReadKey(true);
							break;
						case "7":
							Console.Clear();
							b.verCuentas();
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para ir al menu ");
							Console.ReadKey(true);
							break;
						case "8":
							Console.Clear();
							b.verClientes();
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para ir al menu ");
							Console.ReadKey(true);
							break;
						case "9":
							Console.Clear();
							bucle="NO";
							break;
						case "":
							Console.Clear();
							Console.WriteLine("Se equivoco de opcion, no ingreso nada");
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para ir al menu");
							Console.ReadKey(true);
							break;
						default:
							Console.Clear();
							Console.WriteLine("Se equivoco de opcion");
							Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
							Console.Write("Presione alguna tecla para ir al menu ");
							Console.ReadKey(true);
							break;
				}
			}
			Console.Write("Presione alguna tecla para salir del programa. . . ");
			Console.ReadKey(true);
		}
		public static void verClienteConMasDeUnaCuenta(ArrayList m, ArrayList b){
					if(m.Count>0){
					Console.WriteLine("");
					Console.WriteLine("Lista de cliente con mas de un cuenta:");
					Console.WriteLine("");
					foreach(Cliente c in m){
						Console.WriteLine("Titular: {0} DNI: {1}",c.NomApe,c.Dni);
						foreach(Cuenta cc in b){
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
				}
	}
}