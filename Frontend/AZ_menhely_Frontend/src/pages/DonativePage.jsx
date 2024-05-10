import logo2 from "../assets/LOGO11.png";
import styles from '../styles/DonativePage.module.css';

function DonativePage() {
  return (
    <div className={styles['donative-page']}>
      <header>
        <h1>Adományozás</h1>
        <ul className={styles['contact-info']}>
          <li>Adója 1% : 1819 6384-1-42</li>
          <li>Bankszámla szám : 91179117-200402040</li>
          <li>Önkéntes munka vállalása</li>
          <li>Egyéb adományok: élelmiszer, tárgyi adományok például : takaró, játék </li>
        </ul>
      </header>

      <main>
        <div className={styles['card']}>
          <div className={styles['card-body']}>
            <img src={logo2} alt='Logo' className={styles['img-fluid']} />
          </div>
        </div>
      </main>

      <footer>
        <div className={styles['footer']}>
          <h3>Köszönetnyilvánítás</h3>
          <p>Itt jelenítheted meg a köszönetnyilvánítást vagy bármilyen további tartalmat.</p>
        </div>
      </footer>
    </div>
  );
}

export default DonativePage;