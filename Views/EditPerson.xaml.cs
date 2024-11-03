using Microsoft.Win32;
//using SharedWithYouCore;

namespace odiazTS5A.Views;

public partial class EditPerson : ContentPage
{
    private int personId = 0;
	public EditPerson(int id, String name)
	{
		InitializeComponent();
        txtEditNombre.Text = name;
        personId = id;

    }

    private void txtSaveNewName_Clicked(object sender, EventArgs e)
    {
        App.personRepo.UpdatePerson(personId, txtEditNombre.Text);
        DisplayAlert("Estado", $"Actualizado exitosamente", "OK");
        Navigation.PushAsync(new Register());
    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Register());
    }
}