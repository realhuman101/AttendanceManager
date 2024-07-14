import * as API from '../api/index';

interface Props {
	navItems: Array<string>;
	navRedirect: Array<string>;
	loggedIn: boolean;
}

const Navbar = ({navItems, navRedirect, loggedIn} : Props) => {
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
					}}>Log In</button> 
					
					: <button type="button" onClick={() => {
						API.Auth.logout()
						window.location.href='/login'
					}}>Log Out</button>}
			</div>
		</nav>
	)
}

export default Navbar