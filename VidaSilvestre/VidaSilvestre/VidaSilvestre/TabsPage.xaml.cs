using VidaSilvestre.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace VidaSilvestre
{
	public partial class TabsPage
	{        
        
        Elemento elemento = null;
        public TabsPage(Elemento e )
		{
			InitializeComponent();
            this.elemento = e;
            detalle();
            if (e.Species.Profile != null)
            {
                if (e.Species.Profile.Image != null)
                {
                    if (e.Species.Profile.Image.Count>0)
                    {
                        backgroundImage.Source = e.Species.Profile.Image[0].URL;
                    }
                    else { noImage.Text = "No disponible"; }
                }
                else { noImage.Text = "No disponible"; }
            }
            else { noImage.Text = "No disponible"; }
            
        }
        private void detalle()
        {
            lbNombre.Text = elemento.Species.ScientificName;
            lbClassCommonName.Text = elemento.Species.ClassCommonName;
            lbAcceptedCommonName.Text = elemento.Species.AcceptedCommonName;
            lbKingdomName.Text = elemento.Species.KingdomName;
            lbKingdomCommonName.Text = elemento.Species.KingdomCommonName;
            lbClassName.Text = elemento.Species.ClassName;
            lbFamilyName.Text = elemento.Species.FamilyName;
            lbFamilyCommonName.Text = elemento.Species.FamilyCommonName;
            lbFamilyRank.Text = elemento.Species.FamilyRank; 
        }
    }
}
