import { FormEvent, useState } from "react"
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'

import * as API from "../api/index"

interface Props {
	onLogIn: () => void
}

const Login = ({onLogIn = () => {}} : Props) => {
	const [email, setEmail] = useState('')
	const [password, setPassword] = useState('')

	const onSubmit = async (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();

		if (email.trim().length != 0 && password.length != 0) {
			const response = await API.Auth.login(email.trim(), password);
			const responseCode: number = response.status;

			if (200 <= responseCode && responseCode < 300) { 
				withReactContent(Swal).fire({
					title: "Successfully signed in!",
					icon: "success"
				});
				onLogIn();
			}
			else if (responseCode == 401)
				withReactContent(Swal).fire({
					title: "Failure...",
					text: "Credentials do not match our records",
					icon: "error"
				});
			else
			withReactContent(Swal).fire({
				title: "Failure...",
				text: "An error occurred... Please try again later!",
				icon: "error"
			});
		}
		else
			withReactContent(Swal).fire({
				title: "Please fill in all fields",
				icon: "error"
			});
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