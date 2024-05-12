import styles from '../styles/ContactPage.module.css';

function ContactPage() {
  return (
    <div className={styles['contact-page']}>
      <header>
        <h2>Elérhetőségeink</h2>
      </header>

      <main>
        <ul className={styles['contact-info']}>
          <li>Email: info@azmenhely.hu</li>
          <li>Telefonszám: +36 40 999 4444</li>
          <li>Cím: 1131 Budapest, Menhely utca 3.</li>
        </ul>
        
        {/* A térkép beágyazása */}
        <div className={styles['map-card']}>
          <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d86110.24894947247!2d18.95077319726563!3d47.5883064!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4741da6d70c12fa7%3A0x86c404e84b47541e!2sRex%20Kutyaotthon%20Alap%C3%ADtv%C3%A1ny!5e0!3m2!1shu!2shu!4v1712432251402!5m2!1shu!2shu" width="600" height="450" style={{ border: 0 }} allowfullscreen="" loading="lazy"></iframe>
        </div>
      </main>

      <footer>
        <p>© 2024 Az Menhely. Minden jog fenntartva.</p>
      </footer>
    </div>
  );
}

export default ContactPage;