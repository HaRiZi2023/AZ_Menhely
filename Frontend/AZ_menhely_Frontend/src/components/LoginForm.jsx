function LoginForm() {
    return ( <form>
        <div>
            <label htmlFor="email">Email:</label>
            <input type="email" id="email" placeholder="E-mail" />
        </div>
        <div>
            <label htmlFor="password">Jelszó</label>
            <input type="text" id="password" placeholder="Jelszó" />
        </div>
        <button type="submit">Bejelentkezés</button>
    </form> );
}

export default LoginForm;