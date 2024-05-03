import React from "react";

function ContactPage() {
  return (
    <div>
      <h2>Elérhetőségünk</h2>
      <p>Ha bármilyen kérdése, észrevétele vagy javaslata van az alkalmazással kapcsolatban, kérjük, vegye fel velünk a kapcsolatot az alábbi elérhetőségek egyikén:</p>
      <ul>
        <li>Email: info@azmenhely.hu</li>
        <li>Telefonszám: +36 40 999 4444</li>
        <li>Cím: 1131 Budapest, Menhely utca 3.</li>
      </ul>
      
      {/* A térkép beágyazása */}
      <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d86110.24894947247!2d18.95077319726563!3d47.5883064!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4741da6d70c12fa7%3A0x86c404e84b47541e!2sRex%20Kutyaotthon%20Alap%C3%ADtv%C3%A1ny!5e0!3m2!1shu!2shu!4v1712432251402!5m2!1shu!2shu" width="800" height="600" style={{ border: 0 }} allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
    </div>
  );
}

export default ContactPage;
