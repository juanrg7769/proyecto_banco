/*
 * Creado por SharpDevelop.
 * Usuario: SALAFAR
 * Fecha: 27/10/2022
 * Hora: 10:12
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;

namespace Proyecto_Banco
{
	public class Cliente{
		
		//atributos
		private string nomApe;
		private string dni;
		private string direccion;
		private int telefono;
		private string mail;
		//constructor
		public Cliente(string nomApe,string dni,string direccion,int telefono,string mail){
			
			this.nomApe=nomApe;
			this.dni=dni;
			this.direccion=direccion;
			this.telefono=telefono;
			this.mail=mail;

		}
		
		//propiedades
		public string NomApe{
			get{
				return nomApe;
			}
			set{
				nomApe=value;
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
		public string Direccion{
			get{
				return direccion;
			}
			set{
				direccion=value;
			}
		}
		public int Telefono{
			get{
				return telefono;
			}
			set{
				telefono=value;
			}
		}
		public string Mail{
			get{
				return mail;
			}
			set{
				mail=value;
			}
		}
	}
}