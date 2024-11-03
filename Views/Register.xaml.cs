using Microsoft.Win32;
using odiazTS5A.Models;

namespace odiazTS5A.Views;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        App.personRepo.AddNewPerson(txtNombre.Text);
        statusMessage.Text = App.personRepo.StatusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        List<Person> peolpe = App.personRepo.GetAllPeople();
        listaPersonas.ItemsSource = peolpe;
    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        // Obtener el botón que fue clickeado
        var button = sender as Button;

        // Obtener el elemento de la lista (Person) a través del BindingContext del botón
        var person = button.BindingContext as Person;

        if (person != null)
        {
            // Aquí puedes capturar el Id y el Name de la persona
            int personId = person.Id;
            string personName = person.Name;

            // Ahora puedes usar personId y personName para lo que necesites
            // Por ejemplo, podrías navegar a una página de edición o mostrar un mensaje
            //DisplayAlert("Edit Person", $"Editing {personName} (ID: {personId})", "OK");
            Navigation.PushAsync(new EditPerson(personId, personName));
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        // Obtener el botón que fue clickeado
        var button = sender as Button;

        // Obtener el elemento de la lista (Person) a través del BindingContext del botón
        var person = button.BindingContext as Person;

        if (person != null)
        {
            // Aquí puedes capturar el Id y el Name de la persona
            int personId = person.Id;

            // Ahora puedes usar personId y personName para lo que necesites
            // Por ejemplo, podrías navegar a una página de edición o mostrar un mensaje
            DisplayAlert("Eliminar", $"Persona eliminada correctamente", "OK");
            App.personRepo.DeletePerson(personId);
            List<Person> peolpe = App.personRepo.GetAllPeople();
            listaPersonas.ItemsSource = peolpe;
        }
    }
}