import  { useState } from "react";

function AdoptionHomePetPage() {
  const [formData, setFormData] = useState({
    nev: "",
    telefon: "",
    lakcim: "",
    email: "",
    egyebelerhetosegek: "",
    egyeb: ""
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch('http://localhost:3000/api/orokbefogadas', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
      });
      if (response.ok) {
        alert('Az űrlap sikeresen elküldve!');
      } else {
        alert('Hiba történt az űrlap elküldése közben.');
      }
    } catch (error) {
      console.error('Hiba történt az űrlap elküldése közben:', error);
    }
  };

  <div className="mb-3">
    <label htmlFor="telefon" className="form-label">Telefonszám:</label>
    <input type="text" id="telefon" name="telefon" value={formData.telefon} onChange={handleChange} className="form-control" />
  </div>


  return (
    <div>
      <h2 className="mt-4">Örökbefogadás űrlap</h2>
      <form onSubmit={handleSubmit} className="mt-4">
        {/* Az input mezők és textarea megőrzik a változásokat és az állapotot */}
        <div className="mb-3">
          <label htmlFor="nev" className="form-label">Örökbefogadó neve:</label>
          <input type="text" id="nev" name="nev" value={formData.nev} onChange={handleChange} className="form-control" />
        </div>
        <div className="mb-3">
          <label htmlFor="telefon" className="form-label">Telefonszám:</label>
          <input type="text" id="telefon" name="telefon" value={formData.telefon} onChange={handleChange} className="form-control" />
        </div>
        <div className="mb-3">
          <label htmlFor="lakcim" className="form-label">Lakcím:</label>
          <input type="text" id="lakcim" name="lakcim" value={formData.lakcim} onChange={handleChange} className="form-control" />
        </div>
        <div className="mb-3">
          <label htmlFor="email" className="form-label">Email:</label>
          <input type="email" id="email" name="email" value={formData.email} onChange={handleChange} className="form-control" />
        </div>
        <div className="mb-3">
          <label htmlFor="egyebelerhetosegek" className="form-label">Egyéb elérhetőség:</label>
          <input type="text" id="egyebelerhetoseg" name="egyebelerhetoseg" value={formData.egyebelerhetoseg} onChange={handleChange} className="form-control" />
        </div>
        <div className="mb-3">
          <label htmlFor="egyeb" className="form-label">Egyéb megjegyzés:</label>
          <textarea id="egyeb" name="egyeb" value={formData.egyeb} onChange={handleChange} className="form-control"></textarea>
        </div>
        {/* További input mezők... */}
        <button type="submit" className="btn btn-primary">Űrlap beküldése</button>
      </form>
    </div>
  );
}

export default AdoptionHomePetPage;
