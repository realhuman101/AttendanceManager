import React from 'react'

const Login = () => {
  return (
	<div id="login">
		<h1>Log In</h1>
		<form action="">
			<label htmlFor="email">Enter your email: </label>
			<input type="email" name="email" id="email" placeholder="your@email.com" required />
			
			<label htmlFor="Password">Enter your password: </label>
			<input type="password" name="password" id="password" placeholder="Password" required />

			<input type="submit" value="Log In" />
		</form>
	</div>
  )
}

export default Login