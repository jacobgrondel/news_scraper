 <TextBlock Height="23" HorizontalAlignment="Left" Margin="66,120,0,0" Name="textBlock1" Text="Email" VerticalAlignment="Top" Width="67" />
        <TextBlock Height="23" HorizontalAlignment="Left" Margin="58,168,0,0" Name="textBlock2" Text="Password" VerticalAlignment="Top" Width="77" />
        <TextBox Height="23" HorizontalAlignment="Left" Margin="118,115,0,0" Name="textBoxEmail" VerticalAlignment="Top" Width="247" />
        <PasswordBox Height="23" HorizontalAlignment="Left" Margin="118,168,0,0" Name="passwordBox1" VerticalAlignment="Top" Width="247" />
        <Button Content="Login" Height="23" HorizontalAlignment="Left" Margin="118,211,0,0" Name="button1" VerticalAlignment="Top" Width="104" Click="button1_Click" />
        <TextBlock Height="23" HorizontalAlignment="Left" x:Name ="errormessage" VerticalAlignment="Top" Width="247" Margin="118,253,0,0"  OpacityMask="Crimson" Foreground="#FFE5572C"  />


        <TextBlock Height="50" HorizontalAlignment="Left" Margin="24,48,0,0" Name="textBlockHeading" VerticalAlignment="Bottom" FontSize="12" FontStyle="Italic" Padding="5">
            Note: Please login here to view the features of this site. If you are new on this site then <LineBreak /><!--line break-->
            please click on
           <!--textblock as a Hyperlink.-->
            <TextBlock>
                 <Hyperlink Click="buttonRegister_Click" FontSize="14" FontStyle="Normal">Register</Hyperlink>
            </TextBlock> 
            <!--end textblock as a hyperlink-->
            button
        </TextBlock>
















 <TextBlock Height="23" HorizontalAlignment="Left" Margin="10,5,0,0" Name="textBlockHeading" Text="Registration:" VerticalAlignment="Top" Width="110"  FontSize="17" FontStretch="ExtraCondensed"/>
        <!--Button as a Link button using style-->
        <Button Margin="451,5,12,288" Content="Login" Cursor="Hand" Click="Login_Click">
            <Button.Template>
                <ControlTemplate TargetType="Button">
                    <TextBlock TextDecorations="Underline"> 
                    <ContentPresenter />
                    </TextBlock>
                </ControlTemplate>
            </Button.Template>
            <Button.Style>
                <Style TargetType="Button">
                    <Setter Property="Foreground" Value="Navy" />
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="true">
                            <Setter Property="Foreground" Value="Red" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
        <!--end Button as a Link button using style-->
        <Grid Margin="31,0,29,23" Background="White" Height="264" VerticalAlignment="Bottom">
            <Grid.RowDefinitions>
                <RowDefinition Height="252*" />
                <!--   <RowDefinition Height="12*" />-->
            </Grid.RowDefinitions>
            <TextBlock Height="20" HorizontalAlignment="Left" Margin="67,0,0,0" x:Name ="errormessage" VerticalAlignment="Top" Width="247"  OpacityMask="Crimson" Foreground="#FFE5572C" />
            <TextBlock Height="23" HorizontalAlignment="Left" Margin="67,20,0,0" Name="textBlockFirstname" Text="First Name:" VerticalAlignment="Top" Width="110" />
            <TextBlock Height="23" HorizontalAlignment="Left" Margin="67,50,0,0" Name="textBlockLastName" Text="Last Name:" VerticalAlignment="Top" Width="110" />
            <TextBlock Height="23" HorizontalAlignment="Left" Margin="67,80,0,0" Name="textBlockEmailId" Text="EmailId" VerticalAlignment="Top" Width="110" />
            <TextBlock Height="23" HorizontalAlignment="Left" Margin="67,107,0,0" Name="textBlockPassword" Text="Password:" VerticalAlignment="Top" Width="110"  />
            <TextBlock Height="23" HorizontalAlignment="Left" Margin="67,136,0,0" Name="textBlockConfirmPwd" Text="ConfirmPassword:" VerticalAlignment="Top" Width="110" Grid.RowSpan="2" />
            <!--<TextBlock Height="23" HorizontalAlignment="Left" Margin="67,166,0,0" Name="textBlockAddress" Text="Address" VerticalAlignment="Top" Width="110" />-->

            <TextBox Height="23" HorizontalAlignment="Left" Margin="183,20,0,0" Name="textBoxFirstName" VerticalAlignment="Top" Width="222" />
            <TextBox Height="23" HorizontalAlignment="Left" Margin="183,50,0,0" Name="textBoxLastName" VerticalAlignment="Top" Width="222" />
            <TextBox Height="23" HorizontalAlignment="Left" Margin="183,80,0,0" Name="textBoxEmail" VerticalAlignment="Top" Width="222" />

            <PasswordBox Height="23" HorizontalAlignment="Left" Margin="183,107,0,0" Name="passwordBox1" VerticalAlignment="Top" Width="222" />
            <!--For password-->
            <PasswordBox Height="23" HorizontalAlignment="Left" Margin="183,136,0,0" Name="passwordBoxConfirm" VerticalAlignment="Top" Width="222" />
            <!--<TextBox Height="23" HorizontalAlignment="Left" Margin="183,0,0,66" Name="textBoxAddress" VerticalAlignment="Bottom" Width="222" />-->
            <Button Content="Submit" Height="23" HorizontalAlignment="Left" Margin="183,180,0,0" Name="Submit" VerticalAlignment="Top" Width="70" Click="Submit_Click" />
            <Button Content="Reset" Height="23" HorizontalAlignment="Left" Margin="259,180,0,0" Name="button2" VerticalAlignment="Top" Width="70" Click="button2_Click" />
            <Button Content="Cancel" Height="23" HorizontalAlignment="Right" Margin="0,180,60,0" Name="button3" VerticalAlignment="Top" Width="70" Click="button3_Click" />
        </Grid>