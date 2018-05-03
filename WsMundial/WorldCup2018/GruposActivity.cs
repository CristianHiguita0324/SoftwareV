using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WorldCup2018.Model;
using WorldCup2018.Repository;

namespace WorldCup2018
{
    [Activity(Label = "Grupos")]
    public class GruposActivity : Activity
    {
        private EditText txtCodigoG, txtNombreG;
        private Button btnGuardar, btnEliminar, btnActualizar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Grupos);
            txtCodigoG = FindViewById<EditText>(Resource.Id.txtcodigoGrupo);
            txtNombreG = FindViewById<EditText>(Resource.Id.txtnombreGrupo);
            btnGuardar = FindViewById<Button>(Resource.Id.buttonSaveGrupo);
            btnEliminar = FindViewById<Button>(Resource.Id.buttonDeleteGrupo);
            btnActualizar = FindViewById<Button>(Resource.Id.buttonUpdateGrupo);

          
            btnGuardar.Click += BtnGuardar_Click;




        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Instanciar el repositorio
            GrupoRepository Repositorio = new GrupoRepository();
            //instancamos la clase grupo
            Grupo grupo = new Grupo();
            if (txtCodigoG.Text == "" || txtNombreG.Text == "")
            {
                AlertDialog.Builder dialogo = new AlertDialog.Builder(this);
                dialogo.SetMessage("Debe ingrasar todos los datos").SetNegativeButton("Aceptar", delegate { this.Dispose(); }).Create().Show();
            }
            else
            {
                grupo.Codigo = txtCodigoG.Text;
                grupo.NombreGrupo = txtNombreG.Text;
                string respuesta = await Repositorio.AddGroupAsync("http://10.0.2.2:8585/api/Grupos", grupo);
                Toast.MakeText(this, respuesta, ToastLength.Long).Show();
            }

        }
    }
}