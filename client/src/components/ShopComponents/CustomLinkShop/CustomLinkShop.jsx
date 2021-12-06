import { useMatch, useResolvedPath } from "react-router";
import { Link } from "react-router-dom";
import React from "react";

function CustomLinkShop({ children, to, ...props }) {
    let resolved = useResolvedPath(to);
    let match = useMatch({ path: resolved.pathname, end: true });

    return (
        <li className={match ? "active" : ""}>
            <Link
                to={to}
                {...props}
            >
                {children}
            </Link>
        </li>
    );
}

export default CustomLinkShop