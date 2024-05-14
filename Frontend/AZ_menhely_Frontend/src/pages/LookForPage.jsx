import { useEffect, useState } from 'react';
import styles from '../styles/FoundLookPage.module.css';
import commonStyles from '../styles/CommonStyles.module.css';
import { useNavigate } from 'react-router-dom';

function LookForPage() {
  const [founds, setFounds] = useState([]);
  const [isLoading, setIsLoading] = useState(false); // Új állapot
  const apiUrl = "http://localhost:8000/api"; // Az API végpont URL-je
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchFounds() {
        setIsLoading(true); // Betöltés kezdete
      try {
        const response = await fetch(`${apiUrl}/founds`);
        if (!response.ok) {
          throw new Error('Hiba történt a kéréskor.');
        }
        const data = await response.json();
        const convertedFounds = await convertImagesToDataURL(data); // Kép konvertálás
        setFounds(convertedFounds);
      } catch (error) {
        console.error('Hiba történt:', error);
      }
      setIsLoading(false); // Betöltés befejezése
    }

    fetchFounds(); // A lekérdezés meghívása a komponens mountolásakor

  }, [apiUrl]);

  const convertImagesToDataURL = async (data) => {
    const convertedData = await Promise.all(data.map(async (found) => {
      if (found.f_image) {
        const response = await fetch(`${apiUrl}/founds/${found.id}/image`);
        const blob = await response.blob();
        const dataUrl = await new Promise((resolve, reject) => {
          const reader = new FileReader();
          reader.onloadend = () => resolve(reader.result);
          reader.onerror = reject;
          reader.readAsDataURL(blob);
        });
        return { ...found, f_image: dataUrl };
      } else {
        return found;
      }
    }));
    return convertedData;
  };


  return (
    <>
      {isLoading ? ( // Új
        <div className={commonStyles.loader}></div> // Új
      ) : (

        <>
         
          <div>
            <h2 className="text-center my-4">Talált állatok</h2>
          </div>
          <div style={{ textAlign: 'left' }}> {/* Új div a gomb balra igazításához */}
            <button className="btn btn-info" type="button" onClick={() => navigate('/foundlook')}>Vissza</button> {/* Új */}
          </div>
          <br />

          <div className="row justify-content-center">
            {founds.filter(found => found.f_choice === 'Talált').map((found) => ( // Szűrés a "Talált" állatokra
              <div className="col-lg-5 col-md-8 col-sm-12 mb-4" key={found.id}>
                <div className={`${commonStyles.card} ${styles.card}`}>
                  {found.f_image && (
                    <img className={commonStyles['card-img-top']} src={found.f_image} alt="Talált állat képe" />
                  )}
                  <div className={commonStyles['card-body']}>
                    <h5 className={commonStyles['card-title']}><strong>Választás:</strong> {found.f_choice}</h5>
                    <div className="mb-3">
                      <p className="form-label"><strong>Választás:</strong> {found.f_choice}</p>
                    </div>
                    <div className="mb-3">
                      <p className="form-label"><strong>Fajta:</strong> {found.f_species}</p>
                    </div>
                    <div className="mb-3">
                      <p className="form-label"><strong>Nem:</strong> {found.f_gender}</p>
                    </div>
                    <div className="mb-3">
                      <p className="form-label"><strong>Sérülés:</strong> {found.f_injury}</p>
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>
          <div style={{ textAlign: 'center' }}> {/* Új div a gomb középre igazításához */}
            <button className="btn btn-secondary" type="button" onClick={() => window.scrollTo(0, 0)}>Ugrás a lap tetejére</button> 
          </div>
          <br />
          <br />
        </>
      )}
    </>
  );
}

export default LookForPage;
