using AdvancedDevSample.Domain.Exceptions;

namespace AdvancedDevSample.Domain.Entities
{
    /// <summary>
    /// Représente un produit vendable.
    /// </summary>
    public class Product
    {
        public Guid Id { get; private set; } //Identité
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }//false par défaut

        public string Libelle { get; private set; }

        public Product()
        {
            IsActive = true;
        }
        //Pour l'importation depuis la base
        public Product(Guid id, decimal prix, bool isActive, string libelle)
        {
            Id = id;
            Price = prix;
            IsActive = isActive;
            Libelle = libelle;
        }

        /// <summary>
        /// Modifie le prix du produit.
        /// </summary>
        /// <param name="newPrice">Nouveau prix du produit.</param>
        /// <exception cref="DomainException">Levée si le prix est inférieur ou égal à zéro ou si le produit est inactif.</exception>
        public void ChangePrice(decimal newPrice) //Comportement
        {
            if (newPrice <= 0) // Invariant
                throw new DomainException("Le prix doit être positif.");

            if (!IsActive) //Règle Métier
                throw new DomainException("Produit inactif.");

            Price = newPrice;
        }

        public void ApplyDiscount(decimal discount)
        {
            ChangePrice(Price - discount);
        }

        public void ChangeLibelle(string newLibelle)
        {
            if (string.IsNullOrWhiteSpace(newLibelle))
                throw new DomainException("Le libellé ne peut pas être vide.");
            Libelle = newLibelle;
        }
    }
}
