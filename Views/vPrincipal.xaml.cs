using System.Text.RegularExpressions;

namespace aburbanotll1A.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}
    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        string nombre = txtNombre.Text;
        string identificacion = txtIdentificacion.Text;
        string correo = txtCorreo.Text;
        string confirmarCorreo = txtCorreoConfirmacion.Text;
        string apellido = txtApellido.Text;
        string telefono = txtTelefono.Text;
        string contenido = $"Nombre: {nombre}\n" +
                   $"Apellido: {apellido}\n" +
                   $"Identificaci�n: {identificacion}\n" +
                   $"Correo: {correo}\n" +
                   $"Tel�fono: {telefono}\n";


        if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(identificacion) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(confirmarCorreo) || string.IsNullOrEmpty(telefono))
        {
            DisplayAlert("Error", "Por favor ingrese todos los campos ", "Ok");
        }

        if (!Regex.IsMatch(nombre ?? "", @"^[a-zA-Z\s]+$"))
        {
            lblResultado.Text = "Nombre solo debe contener letras.";
            return;
        }

        if (!Regex.IsMatch(identificacion ?? "", @"^\d+$"))
        {
            lblResultado.Text = "C�dula solo debe contener n�meros.";
            return;
        }

        if (correo != confirmarCorreo)
        {
            lblResultado.Text = "Los correos no coinciden.";
            return;
        }

        if (!Regex.IsMatch(apellido ?? "", @"[a-zA-Z\s]+$"))
        {
            lblResultado.Text = "Nombre solo debe contener letras.";
            return;
        }

        try
        {
            // Guardar en archivo de texto
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Datos.txt");
            File.AppendAllText(ruta, contenido); // Agrega al final del archivo
            lblResultado.Text = $"Datos guardados correctamente en:\n{ruta}";
        }
        catch (Exception ex)
        {
            lblResultado.Text = $"Error al guardar: {ex.Message}";
        }
    }

    }