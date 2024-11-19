/*
 * Creado por SharpDevelop.
 * Usuario: SALAFAR
 * Fecha: 27/10/2022
 * Hora: 10:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;

namespace Proyecto_Banco
{
	public class Cuenta
	{
		
		//atributos
		private int numCuent;
		private double saldo;
		private string nomApe;
		private string dni;
		
		//constructor
		public Cuenta(int numCuent,double saldo,string nomApe,string dni){
			
			this.numCuent=numCuent;
			this.saldo=saldo;
			this.nomApe=nomApe;
			this.dni=dni;
		}
	
		public int NumCuent{
			get{
				return numCuent;
			}
			set{
				numCuent=value;
			}
		}
		public string NomApe{
			get{
				return nomApe;
			}
			set{
				nomApe=value;
			}
		}
		public double Saldo{
			get{
				return saldo;
			}
			set{
				saldo=value;
			}
		}
		public string Dni{
			get{
				return dni;
			}
			set{
				dni=value;
			}
		}
	}
}