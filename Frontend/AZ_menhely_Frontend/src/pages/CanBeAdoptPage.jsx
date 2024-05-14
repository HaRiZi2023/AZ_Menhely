import { useEffect, useState } from 'react';
import styles from '../styles/CanBeAdoptPage.module.css';
import commonStyles from '../styles/CommonStyles.module.css';


function CanBeAdoptPage() {
  const [guests, setGuests] = useState([]);
  const [isLoading, setIsLoading] = useState(false); // Új állapot
  const apiUrl = "http://localhost:8000/api"; // Az API végpont URL-je

  useEffect(() => {
    async function fetchGuest() {
      setIsLoading(true); // Betöltés kezdete
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
      setIsLoading(false); // Betöltés befejezése
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



  return (
    <>
      {isLoading ? (
        <div className={commonStyles.loader}></div>
      ) : (
        <>
          <div>
            <h2 className="text-center my-3">Vendégek</h2>
          </div>
          <div className={styles.container} >
            {guests.map((guest) => (
              <div className="col-lg-5 col-md-8 col-sm-12 mb-4" key={guest.id}>
                <div className={`${commonStyles.card} ${styles.card}`}>
                  {guest.g_image && (
                    <img className={commonStyles['card-img-top']} src={guest.g_image} alt="Vendég képe" />
                  )}
                  <div className={commonStyles['card-body']}>
                    <h5 className={commonStyles['card-title']}><strong>ID:</strong> {guest.id}</h5>
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
              </div>
            ))}
          </div>
          <div style={{ textAlign: 'center' }}> {/* Új div a gomb középre igazításához */}
            <button className="btn btn-secondary" type="button"  onClick={() => window.scrollTo(0, 0)}>Ugrás a lap tetejére</button>
          </div>
          <br />
          <br />
        </>
      )}
    </>
  );
}

export default CanBeAdoptPage;
