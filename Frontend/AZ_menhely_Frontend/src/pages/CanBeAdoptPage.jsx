import { useEffect, useState } from 'react';
import styles from '../styles/CanBeAdoptPage.module.css';



function GuestPage() {
  const [guests, setGuests] = useState([]);
  const apiUrl = "http://localhost:8000/api"; // Az API végpont URL-je

  useEffect(() => {
    async function fetchGuest() {
      try {
        const response = await fetch(`${apiUrl}/all-guests`);
        if (!response.ok) {
          throw new Error(`Hiba történt a kéréskor: ${response.status} ${response.statusText}`);
        }

        const data = await response.json();
        const convertedGuests = await convertImagesToDataURL(data); // Kép konvertálás
        setGuests(convertedGuests);
      } catch (error) {
        console.error('Hiba történt:', error);
      }
    }

    fetchGuest(); // A lekérdezés meghívása a komponens mountolásakor

  }, [apiUrl]);

  const convertImagesToDataURL = async (data) => {
    const convertedData = await Promise.all(data.map(async (guest) => {
      if (guest.g_image) {
        const response = await fetch(`${apiUrl}/all-guests/${guest.id}/image`);
        const blob = await response.blob();
        const dataUrl = await new Promise((resolve, reject) => {
          const reader = new FileReader();
          reader.onloadend = () => resolve(reader.result);
          reader.onerror = reject;
          reader.readAsDataURL(blob);
        });
        return { ...guest, g_image: dataUrl };
      } else {
        return guest;
      }
    }));
    return convertedData;
  };
  const handleImageClick = (imageUrl) => {
    alert(`A kép elérési útvonala: ${imageUrl}`);
  };

  
  return (
    <>
      <div>
        <h2 className="text-center my-4">Vendégek</h2>
      </div>
      <div className={styles.container} >
        {guests.map((guest) => (
          <div className={styles.card} key={guest.id}>
            {guest.g_image && (
              <img className={styles['card-image-top']} src={guest.g_image} alt="Vendég képe" onClick={() => handleImageClick(guest.imageUrl)} />
            )}
            <div className={styles['card-body']}>
              <h5 className={styles['card-title']}><strong>ID:</strong> {guest.id}</h5>
              <div className="mb-3">
                <p className="form-label"><strong>Név:</strong> {guest.g_name}</p>
              </div>
              <div className="mb-3">
                <p className="form-label"><strong>Chip:</strong> {guest.g_chip}</p>
              </div>
              <div className="mb-3">
                <p className="form-label"><strong>Faj:</strong> {guest.g_species}</p>
              </div>
              <div className="mb-3">
                <p className="form-label"><strong>Nem:</strong> {guest.g_gender}</p>
              </div>
              <div className="mb-3">
                <p className="form-label"><strong>Érkezés dátuma:</strong> {guest.g_in_date}</p>
              </div>
              <div className="mb-3">
                <p className="form-label"><strong>Érkezés helye:</strong> {guest.g_in_place}</p>
              </div>
              <div className="mb-3">
                <p className="form-label"><strong>Távozás dátuma:</strong> {guest.g_out_date}</p>
              </div>
              <div className="mb-3">
                <p className="form-label"><strong>Örökbefogadás:</strong> {guest.g_adoption}</p>
              </div>
              <div className="mb-3">
                <p className="form-label"><strong>Egyéb:</strong> {guest.g_other}</p>
              </div>
            </div>
          </div>
        ))}
      </div>
    </>


  );
}

export default GuestPage;
