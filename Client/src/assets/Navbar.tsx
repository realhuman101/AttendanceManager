import React from 'react'

interface Props {
	navItems: Array<string>
}

const Navbar = ({navItems} : Props) => {
	return (
		<nav>
			<ul>
				{navItems.map((item) => (
					<li>{item}</li>
				))}
			</ul>
		</nav>
	)
}

export default Navbar