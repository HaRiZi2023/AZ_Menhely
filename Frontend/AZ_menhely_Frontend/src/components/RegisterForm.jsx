function RegisterForm() {
    return ( <form>
        <div>
            <label htmlFor="email">Email:</label>
            <input type="email" id="email" placeholder="E-mail" />
        </div>
        <div>
            <label htmlFor="password">Jelszó</label>
            <input type="text" id="password" placeholder="Jelszó" />
        </div>
        <div>
            <label htmlFor="name">Név</label>
            <input type="text" id="name" placeholder="Név" />
        </div>
        <button type="submit">Regisztráció</button>
    </form> );
}

export default RegisterForm;