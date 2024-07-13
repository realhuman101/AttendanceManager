import { useState } from "react"
import * as API from "../api/index"

const Login = () => {
	const [email, setEmail] = useState('')
	const [password, setPassword] = useState('')

	const onSubmit = () => {
		if (email.trim().length != 0 && password.length != 0)
			API.Auth.login(email.trim(), password);
		// else
	}

	return (
		<div id="login">
			<h1>Log In</h1>
			<form action="" onSubmit={onSubmit}>
				<label htmlFor="email">Enter your email: </label>
				<input type="email" name="email" id="email" placeholder="your@email.com" onInput={e => setEmail((e.target as HTMLInputElement).value)} required />
				
				<label htmlFor="Password">Enter your password: </label>
				<input type="password" name="password" id="password" placeholder="Password" onInput={e => setPassword((e.target as HTMLInputElement).value)} required />

				<input type="submit" value="Log In" />
			</form>
		</div>
	)
}

export default Login