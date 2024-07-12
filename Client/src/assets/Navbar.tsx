import React from 'react'

interface Props {
	navItems: Array<string>;
	navRedirect: Array<string>;
}

const Navbar = ({navItems, navRedirect} : Props) => {
	return (
		<nav id="navbar">
			<ul>
				{navItems.map((item, index) => (
					<li><a href={navRedirect[index]}>{item}</a></li>
				))}
			</ul>
		</nav>
	)
}

export default Navbar