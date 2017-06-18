using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB{

	public class ConexionDB : MonoBehaviour {

		protected DataService db = new DataService();

		protected string ManejoInfoR(IEnumerable<Objective> Var,string Where){

			string Re = "";

			foreach (var Arr in Var) {
				string[] info = Arr.Mostrar ();

				if (info [0] == Where) {

					Re=info[1];

				}
			}

			return Re;

		}

		protected string ManejoInfoR(IEnumerable<Activities> Var,string Where){

			string Re = "";

			foreach (var Arr in Var) {
				string[] info = Arr.Mostrar ();

				if (info [0] == Where) {

					Re=info[2];
				}

			}

			return Re;

		}

		protected string ManejoInfoR(IEnumerable<Option> Var,string Where){

			string Re = "";

			foreach (var Arr in Var) {
				string[] info = Arr.Mostrar ();

				if (info [0] == Where) {

					Re=info[1];
				}

			}

			return Re;

		}
		protected int Ponit(IEnumerable<Option> Var,string Where){

			int Re = 0;

			foreach (var Arr in Var) {
				string[] info = Arr.Mostrar ();

				if (info [0] == Where) {
					
					Re=Int32.Parse(info[2]);

				}

			}

			return  Re;

		}

	}
}
