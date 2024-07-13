import { FormEvent, useState } from "react"
import * as API from "../api/index"

interface Props {
	alertOpacity: (opacity: number) => void,
	alertType: (type: string) => void,
	onLogIn: () => void
}

const Login = ({alertOpacity, alertType, onLogIn = () => {}} : Props) => {
	const [email, setEmail] = useState('')
	const [password, setPassword] = useState('')

	const onSubmit = async (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();

		if (email.trim().length != 0 && password.length != 0) {
			const response = await API.Auth.login(email.trim(), password);
			const responseCode: number = response.status;

			if (200 <= responseCode && responseCode < 300)
				onLogIn();
		}
		else {
			alertType("danger")
			alertOpacity(1)
		}
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