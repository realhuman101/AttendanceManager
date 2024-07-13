import React, { useState } from 'react'

interface Props {
	navItems: Array<string>;
	navRedirect: Array<string>;
}

const Navbar = ({navItems, navRedirect} : Props) => {
	const [loggedIn, setLogIn] = useState(false);

	return (
		<nav id="navbar">
			<div id='navP1'>
				<ul>
					{navItems.map((item, index) => (
						<li><a href={navRedirect[index]}>{item}</a></li>
					))}
				</ul>
			</div>
			<div id='navP2'>
					{!loggedIn ? <button type="button" onClick={() => {
						window.location.href='/login'
					}}>Log In</button> : <button type="button">Log Out</button>}
			</div>
		</nav>
	)
}

export default Navbar