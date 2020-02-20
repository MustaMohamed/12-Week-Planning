import React, { FC, SyntheticEvent, useState } from 'react';
import { Container, Menu, StrictMenuItemProps } from 'semantic-ui-react';

const navs: string[] = ['home', 'about'];
const authNavs: string[] = ['login', 'signup'];

const Navbar: FC = () => {
  const [activeItem, setActiveItem]: [string, (name: string) => void] = useState<string>('home');
  const handleItemClick = (e: SyntheticEvent, { name }: StrictMenuItemProps) => setActiveItem(name || 'home');
  return (
    <Menu pointing secondary>
      <Container fluid>
        {navs && navs.map((item, idx) =>
          <Menu.Item
            name={item}
            active={activeItem === item}
            key={idx}
            onClick={handleItemClick}
          />)
        }
        {
          authNavs && <Menu.Menu position='right'>
            {authNavs.map((item, idx) =>
              <Menu.Item
                name={item}
                active={activeItem === item}
                key={idx}
                onClick={handleItemClick}
              />)}
          </Menu.Menu>
        }
      </Container>
    </Menu>
  );
};

export default Navbar;