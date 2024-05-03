
import logo2 from "../assets/logo2.jpg";

function DonativePage() {
  return (
    <div>
      <h2>Adományozás</h2>
      <div className="card">
        <div className="card-body text-center">
          <img src={logo2} alt='Toggle theme' className="img-fluid mx-auto d-block" />
          <p className="text-center mt-3">Adója 1% : 1819 6384-1-42</p>
          <p className="text-center">Bankszámla szám : 91179117-200402040</p>
          <p className="text-center">Önkéntes munka vállalása</p>
          <p className="text-center">Egyéb adományok: élelmiszer, tárgyi adományok például : takaró, játék </p>
        </div>
      </div>
      
      <div className="mt-4 text-center">
        <h3>Köszönetnyilvánítás</h3>
        <p>Itt jelenítheted meg a köszönetnyilvánítást vagy bármilyen további tartalmat.</p>
      </div>
    </div>
  );
}




export default DonativePage;